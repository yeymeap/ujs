$(document).ready(function () {
	let numDisks = 3;
	let selectedDisk = null;
	const colors = [
		"#FF5733",
		"#33FF57",
		"#3357FF",
		"#FF33A6",
		"#33FFF5",
		"#F5FF33",
		"#FF8F33",
		"#FF33D4",
	];

	function generateDisks(num) {
		$(".tower").empty();
		for (let i = num; i > 0; i--) {
			const disk = $(
				`<div class="disk" data-size="${i}" style="background-color:${
					colors[i - 1]
				}"></div>`
			);
			disk.css("width", `${i * 20 + 30}px`);
			$("#tower1").append(disk);
		}
		positionDisks($("#tower1"));
		bindDiskEvents();
	}

	function bindDiskEvents() {
		$(".tower")
			.off("click")
			.on("click", function () {
				const topDisk = $(this).children().first();
				if (
					selectedDisk &&
					(topDisk.length === 0 ||
						selectedDisk.attr("data-size") <
							topDisk.attr("data-size"))
				) {
					moveDisk(selectedDisk, $(this));
					selectedDisk = null;
				} else if (!selectedDisk && topDisk.length > 0) {
					selectedDisk = topDisk;
				}
			});
	}

	function moveDisk(disk, targetTower) {
		targetTower.prepend(disk);
		positionDisks(targetTower);
		checkWinCondition();
	}

	function positionDisks(tower) {
		const disks = tower.children();
		disks.each(function (index) {
			const diskHeight = $(this).outerHeight(true);
			$(this).css("bottom", `${index * diskHeight}px`);
		});
	}

	function checkWinCondition() {
		if ($("#tower3").children().length === numDisks) {
			$("#message").text("Gratulálunk! Sikerült megoldani a feladványt.");
		}
	}

	$("#startButton").on("click", function () {
		numDisks = parseInt($("#numDisks").val());
		generateDisks(numDisks);
		$("#message").text("");
	});

	generateDisks(numDisks);
});
